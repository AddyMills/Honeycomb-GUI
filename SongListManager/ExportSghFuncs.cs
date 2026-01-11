using GH_Toolkit_Core.Methods;
using GH_Toolkit_Core.QB;
using static GH_Toolkit_Core.Methods.CreateForGame;
using static GH_Toolkit_Core.PAK.PAK;
using static GH_Toolkit_Core.QB.QB;
using static GH_Toolkit_Core.QB.QBArray;
using static GH_Toolkit_Core.QB.QBConstants;
using static GH_Toolkit_Core.QB.QBStruct;
using static GH_Toolkit_Core.QB.QBStruct;
using static GH_Toolkit_GUI.PreCompileChecks;

namespace GH_Toolkit_GUI
{
    public partial class SongListManager
    {
        private void ExportSongs()
        {
            
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = sghFileFilter;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SghPath = dialog.FileName;
                }
                else
                {
                    MessageBox.Show("No file selected to export SGH.", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            var sghFileName = Path.GetFileNameWithoutExtension(SghPath);
            var saveFolder = Path.GetDirectoryName(SghPath); // Testing. Replace with Path.GetFolder of SghPath variable when done testing.
            var saveLocationForFiles = Path.Combine(saveFolder, sghFileName);
            

            Directory.CreateDirectory(saveLocationForFiles);

            List<int> songArrayIndeces = new List<int>();
            List<int> dlSonglistIndeces = new List<int>();
            List<int> dlSongPropsIndeces = new List<int>();

            List<QBItem> songsToExport = new List<QBItem>();

            var musicFolder = Path.Combine(GetGh3Folder(Game), "DATA", "MUSIC");
            var songsFolder = Path.Combine(GetGh3Folder(Game), "DATA", "SONGS");
            foreach (string song in songList.CheckedItems)
            {
                var songName = song.Split(' ')[0];
                Console.WriteLine($"Exporting song: {songName}");
                songArrayIndeces.Add(SongArray.GetItemIndex(songName, QBKEY));
                dlSonglistIndeces.Add(DlSongList.GetItemIndex(songName, QBKEY));
                QBStructData? itemData = null;

                for (int i = 0; i < DlSongListProps.Items.Count; i++)
                {
                    var item = DlSongListProps.Items[i] as QBStructItem;
                    itemData = item.Data as QBStructData;

                    if (itemData["name"] as string == songName)
                    {
                        dlSongPropsIndeces.Add(i);
                        break;
                    }
                }

                if (itemData == null)
                {
                    MessageBox.Show($"Could not find song data for song: {songName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                var fsbPath = Path.Combine(musicFolder, $"{songName}.fsb.xen");
                var datPath = Path.Combine(musicFolder, $"{songName}.dat.xen");
                var songPath = Path.Combine(songsFolder, $"{songName}_song.pak.xen");
                if (!(File.Exists(fsbPath) && File.Exists(datPath) && File.Exists(songPath)))
                {
                    MessageBox.Show($"Missing files for song: {songName}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }
                songsToExport.Add(new QBItem(song, itemData));
                File.Copy(fsbPath, Path.Combine(saveLocationForFiles, $"{songName}.fsb.xen"), true);
                File.Copy(datPath, Path.Combine(saveLocationForFiles, $"{songName}.dat.xen"), true);
                File.Copy(songPath, Path.Combine(saveLocationForFiles, $"{songName}_song.pak.xen"), true);

            }
            var saveQb = Path.Combine(saveLocationForFiles, "songs.info");
            var bytes = QB.CompileQbFile(songsToExport, "songs.info", GAME_GH3, CONSOLE_PC);
            File.WriteAllBytes(saveQb, bytes);
            Console.WriteLine("Creating SGH...");
            if (File.Exists(SghPath))
            {
                File.Delete(SghPath);
            }
            GHTCP.MakeUnprotectedZip(saveLocationForFiles, SghPath);
            Directory.Delete(saveLocationForFiles, true);
            MessageBox.Show($"Exported SGH to: {SghPath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
