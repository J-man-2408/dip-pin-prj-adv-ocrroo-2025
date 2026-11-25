using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace OCRRoo_Frontend
{
    public class AppSettings : INotifyPropertyChanged
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "OCRRoo", "textsize.txt");

        public static AppSettings Instance { get; } = new();

        public const double MinSize = 14;
        public const double MaxSize = 48;

        private double textSize = 20;  

        public event PropertyChangedEventHandler? PropertyChanged;

        private AppSettings()
        {
            Load();
        }

        public double TextSize
        {
            get => textSize;
            set
            {
                double clamped = Math.Clamp(value, MinSize, MaxSize);
                if (clamped == textSize) return;

                textSize = clamped;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextSize)));
                Save();
            }
        }

        private void Load()
        {
            try
            {
                if (File.Exists(FilePath) &&
                    double.TryParse(File.ReadAllText(FilePath), NumberStyles.Float,
                                    CultureInfo.InvariantCulture, out double saved))
                {
                    textSize = Math.Clamp(saved, MinSize, MaxSize);
                }
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }

        private void Save()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
                File.WriteAllText(FilePath, textSize.ToString(CultureInfo.InvariantCulture));
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }
    }
}