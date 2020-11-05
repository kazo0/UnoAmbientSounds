using AmbientSounds.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Storage;

namespace AmbientSounds.Services.Uwp
{
    /// <summary>
    /// A provider of sound data.
    /// </summary>
    public sealed class SoundDataProvider : ISoundDataProvider
    {
        private const string DataFileName = "Data.json";

        /// <inheritdoc/>
        public async Task<IList<Sound>> GetSoundsAsync()
        {
            string path = "ms-appx:///Assets/Data.json";
            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            StorageFile dataFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(path));

            using Stream dataStream = await dataFile.OpenStreamForReadAsync();
            var c = await JsonSerializer.DeserializeAsync<Sound[]>(dataStream);
            return c;
        }
    }
}
