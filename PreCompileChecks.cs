using GH_Toolkit_Core.PAK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GH_Toolkit_Core.QB.QBConstants;
using static GH_Toolkit_Core.Methods.CreateForGame;

namespace GH_Toolkit_GUI
{
    public class PreCompileChecks
    {
        private const string DATA_PATH = "DATA";
        private const string PAK_FOLDER = "PAK";
        private const string MUSIC_FOLDER = "MUSIC";
        private const string SONGS_FOLDER = "SONGS";
        private const string BACKUPS_FOLDER = "Backups";
        private const string REPLACEMENTS_FOLDER = "Replacements";
        private const string RESOURCES_FOLDER = "Resources";
        private const string QB_FOLDER = "QB";
        private const string CUSTOMS_PAK_FILENAME = "customs.pak.xen";
        private const string PATCH_PAK_FILENAME = "patch.pak.xen";
        private const string QB_PAK_FILENAME = "qb";
        private const string GH3_EXE_NAME = "GH3";
        private const string GHA_EXE_NAME = "Guitar Hero Aerosmith";
        private const string ONYX_EXE_NAME = "onyx.exe";
        private const string BETTERGH3_FOLDER = "BetterGH3";

        internal static readonly string ExeLocation = Assembly.GetExecutingAssembly().Location;
        internal static readonly string ExeDirectory = Path.GetDirectoryName(ExeLocation)!;
        internal static readonly string ResourcePath = Path.Combine(ExeDirectory, RESOURCES_FOLDER);
        private static readonly string BackupsPath = Path.Combine(ExeDirectory, BACKUPS_FOLDER);
        private static readonly string ReplacementsPath = Path.Combine(ExeDirectory, REPLACEMENTS_FOLDER);

        public static string DATAPath => DATA_PATH;
        public static string PAKPath => Path.Combine(DATA_PATH, PAK_FOLDER);
        public static string MUSICPath => Path.Combine(DATA_PATH, MUSIC_FOLDER);
        public static string SONGSPath => Path.Combine(DATA_PATH, SONGS_FOLDER);

        private static UserPreferences Preferences => UserPreferences.Default;
        public static void Gh3PcCheck(string game, bool suppressMessages = false)
        {
            string backupLocation = Path.Combine(BackupsPath, game);
            string qbPakBackupLocation = Path.Combine(backupLocation, QB_FOLDER);
            string gameName = GetGameDisplayName(game);
            string exeName = GetGameExeName(game);
            
            string ghPath = ValidateAndGetGamePath(game, gameName, exeName, out bool pathChanged);

            if (game == GAME_GH3)
            {
                CopyResourceFilesIfNeeded(ghPath, gameName, suppressMessages);
            }

            string ghQbPakPath = Path.Combine(ghPath, PAKPath, $"{QB_PAK_FILENAME}.pak.xen");
            string ghQbPabPath = Path.Combine(ghPath, PAKPath, $"{QB_PAK_FILENAME}.pab.xen");
            
            bool backedUp = BackupQbFilesIfNeeded(qbPakBackupLocation, ghQbPakPath, ghQbPabPath, backupLocation, gameName);

            if (backedUp)
            {
                ReplaceGh3PakFiles(game, "PC");
            }

            if (pathChanged)
            {
                UpdateGameFilePreferences(game, ghQbPakPath, ghQbPabPath, ghPath);
            }
        }
        private static void UpdateGameFilePreferences(string game, string pakPath, string pabPath, string folderPath)
        {
            if (game == GAME_GH3)
            {
                Preferences.Gh3QbPak = pakPath;
                Preferences.Gh3QbPab = pabPath;
                Preferences.Gh3FolderPath = folderPath;
            }
            else
            {
                Preferences.GhaQbPak = pakPath;
                Preferences.GhaQbPab = pabPath;
                Preferences.GhaFolderPath = folderPath;
            }
            Preferences.Save();
        }
        public static string GetGh3PakFile(string game) =>
            game == GAME_GH3 ? Preferences.Gh3QbPak : Preferences.GhaQbPak;

        public static string GetGh3Folder(string game) =>
            game == GAME_GH3 ? Preferences.Gh3FolderPath : Preferences.GhaFolderPath;
        public static string GetCustomsPak(string game) =>
            game == GAME_GH3 ? Path.Combine(GetGh3Folder(game), DATA_PATH, CUSTOMS_PAK_FILENAME) : GetGh3PakFile(game);
        public static void OverwriteGh3Pak(byte[] pakData, byte[] pabData, string game)
        {
            string pak = GetCustomsPak(game);
            if (game == GAME_GH3)
            {
                OverwritePak(pak, pakData, DOTXEN);
            }
            else
            {
                OverwriteSplitPak(pak, pakData, pabData, DOTXEN);
            }
               
        }
        public static void ReplaceGh3PakFiles(string game, string platform)
        {
            if (game == GAME_GH3) return;

            string qbPakLocation = GetGh3PakFile(game);
            string replaceLocation = Path.Combine(ReplacementsPath, platform, game, QB_FOLDER);

            if (!Directory.Exists(replaceLocation)) return;

            var pakCompiler = new PAK.PakCompiler(game, platform, split: true);
            var replaceFiles = Directory.GetFiles(replaceLocation, "*.qb", SearchOption.AllDirectories);
            var qbPak = PAK.PakEntryDictFromFile(qbPakLocation);
            
            foreach (var file in replaceFiles)
            {
                string relPath = Path.GetRelativePath(replaceLocation, file);
                if (qbPak.TryGetValue(relPath, out var entry))
                {
                    byte[] qbData = File.ReadAllBytes(file);
                    entry.OverwriteData(qbData);
                }
            }
            
            var (pakData, pabData) = pakCompiler.CompilePakFromDictionary(qbPak);
            OverwriteGh3Pak(pakData, pabData!, game);
        }
        public static void OnyxCheck()
        {
            string onyxPath = Preferences.OnyxCliPath;
            string onyxExe = Path.Combine(onyxPath, ONYX_EXE_NAME);
            bool showWarning = true;
            
            while (!Directory.Exists(onyxPath) || !File.Exists(onyxExe))
            {
                if (showWarning)
                {
                    MessageBox.Show("Onyx has not been found. Please select your Onyx CLI folder now.", "Folder Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showWarning = false;
                }
                
                string tempOnyxFolder = AskForGamePath();
                string tempOnyxExe = Path.Combine(tempOnyxFolder, ONYX_EXE_NAME);
                
                if (!File.Exists(tempOnyxExe))
                {
                    MessageBox.Show("Onyx.exe was not found in the selected folder. Please select the correct folder.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Preferences.OnyxCliPath = tempOnyxFolder;
                    Preferences.Save();
                    onyxPath = tempOnyxFolder;
                    onyxExe = tempOnyxExe;
                }
            }
        }
        public static string AskForGamePath()
        {
            while (true)
            {
                using var dialog = new FolderBrowserDialog { ShowNewFolderButton = false };
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    throw new OperationCanceledException("User cancelled the path selection.");
                }

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    if (Directory.Exists(dialog.SelectedPath))
                    {
                        return dialog.SelectedPath;
                    }
                    MessageBox.Show("The selected path does not exist. Please select a valid path.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Please select a valid path.", "Path Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private static string GetGameDisplayName(string game) =>
            game == GAME_GH3 ? "Guitar Hero III" : GHA_EXE_NAME;

        private static string GetGameExeName(string game) =>
            game == GAME_GH3 ? GH3_EXE_NAME : GHA_EXE_NAME;

        private static string ValidateAndGetGamePath(string game, string gameName, string exeName, out bool pathChanged)
        {
            string ghPath = GetGh3Folder(game);
            pathChanged = false;

            try
            {
                if (string.IsNullOrEmpty(ghPath))
                {
                    ghPath = AskForGamePath();
                    pathChanged = true;
                }

                while (true)
                {
                    string ghExePath = Path.Combine(ghPath, $"{exeName}.exe");
                    if (File.Exists(ghExePath))
                    {
                        break;
                    }

                    MessageBox.Show($"The game executable was not found in the selected path. Please select the correct {gameName} game folder.", "Game Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ghPath = AskForGamePath();
                    pathChanged = true;
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show($"{gameName}'s game path is required to proceed.\n\nCancelling compilation.", "Path Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to get the game path.\n\n{ex.Message}\n\nCancelling compilation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return ghPath;
        }

        private static void CopyResourceFilesIfNeeded(string ghPath, string gameName, bool forceCopy = false)
        {
            string patchPakPath = Path.Combine(ghPath, DATA_PATH, PATCH_PAK_FILENAME);
            if (!File.Exists(patchPakPath))
            {
                throw new FileNotFoundException($"Required file {PATCH_PAK_FILENAME} not found in {gameName}'s DATA folder.\n\nPlease re-download BetterGH3.");
            }
            string customsPakPath = Path.Combine(ghPath, DATA_PATH, CUSTOMS_PAK_FILENAME);
            if (File.Exists(customsPakPath) && !forceCopy) return;

            try
            {
                string gameDataPath = Path.Combine(ghPath, DATA_PATH);
                string betterGh3FilesPath = Path.Combine(ResourcePath, BETTERGH3_FOLDER);
                if (!Directory.Exists(betterGh3FilesPath)) return;

                var betterGh3Files = Directory.GetFiles(betterGh3FilesPath, "*.*", SearchOption.AllDirectories);
                foreach (string file in betterGh3Files)
                {
                    string relativePath = Path.GetRelativePath(betterGh3FilesPath, file);
                    string destPath = Path.Combine(gameDataPath, relativePath);
                    Directory.CreateDirectory(Path.GetDirectoryName(destPath)!);
                    File.Copy(file, destPath, overwrite: true);
                }
                if (forceCopy) return;
                MessageBox.Show($"Better {gameName} has been updated to allow customs online!\n\nSave files will also no longer break when adding new songs.", "BetterGH3 Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while copying update files to {gameName}'s DATA folder.\n\n{ex.Message}\n\nCancelling compilation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private static bool BackupQbFilesIfNeeded(string qbPakBackupLocation, string ghQbPakPath, string ghQbPabPath, string backupLocation, string gameName)
        {
            if (File.Exists(qbPakBackupLocation + DOT_PAK_XEN)) return false;

            Directory.CreateDirectory(backupLocation);

            try
            {
                File.Copy(ghQbPakPath, qbPakBackupLocation + DOT_PAK_XEN);
                File.Copy(ghQbPabPath, qbPakBackupLocation + DOT_PAB_XEN);
                MessageBox.Show($"A backup of {gameName}'s QB file has been created.\nIt can be copied back to your GH folder at any time in the settings menu.", "Backup Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to backup {gameName}'s QB.PAK file.\n\n{ex.Message}\n\nCancelling compilation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
