﻿using System.Diagnostics;

namespace GH_Toolkit_Exceptions
{
    public static class Exceptions
    {
        public static void HandleException(Exception ex, string errorInfo = "Error")
        {
            var st = new StackTrace(ex, true);
            StackFrame targetFrame = null;

            foreach (var frame in st.GetFrames())
            {
                var method = frame.GetMethod();
                if (method != null &&
                    !method.DeclaringType.Assembly.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase) &&
                    !method.DeclaringType.Assembly.FullName.StartsWith("Microsoft", StringComparison.OrdinalIgnoreCase))
                {
                    targetFrame = frame;
                    break;
                }
            }

            if (targetFrame != null)
            {
                var fileName = Path.GetFileName(targetFrame.GetFileName()) ?? "Not available";
                var methodName = targetFrame.GetMethod().Name;
                var line = targetFrame.GetFileLineNumber();
                var column = targetFrame.GetFileColumnNumber();

                string errorMessage = $"Exception: {ex.Message}\nMethod: {methodName}\nFile: {fileName}\nLine: {line}, Column: {column}";
                MessageBox.Show(errorMessage, errorInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Fallback message if no suitable frame is found
                MessageBox.Show($"Exception: {ex.Message}", "errorMessage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public static void MidiFailException(Exception ex)
        {
            Console.WriteLine($"Errors were found while compiling the MIDI:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Compilation has been cancelled.");
            MessageBox.Show("Errors were found while compiling the MIDI.\nPlease refer to the log on the toolkit's main window.", "MIDI Compilation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Make a custom error handler in the near future
        }

        public static void SkaFailException(Exception ex)
        {
            Console.WriteLine($"Errors were found while processing the SKA Files:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Compilation has been cancelled.");
            MessageBox.Show("Errors were found while processing the SKA.\nPlease refer to the log on the toolkit's main window.", "SKA Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Make a custom error handler in the near future
        }
    }
}