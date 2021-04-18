﻿using LocalNote.Models;
using LocalNote.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace LocalNote.Repositories
{
    public class LocalNoteRepo
    {

        // create a storage folder
        private static StorageFolder textfileFolder = ApplicationData.Current.LocalFolder;
        
        // create a file with the given text
        public async void CreateNewFile(string fileName, string text)
        {
            try
            {
                Windows.Storage.StorageFile sampleFile = await textfileFolder.CreateFileAsync((fileName + ".txt"),
                    Windows.Storage.CreationCollisionOption.OpenIfExists);
                await Windows.Storage.FileIO.AppendTextAsync(sampleFile, text);
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Oh noes! An error occurred with file creating " + ex.Message);
            }
        }

        // edit an existing file
        public async void WriteToFile(string text, string fileName)
        {
            try
            {
                Windows.Storage.StorageFile sampleFile =
                    await textfileFolder.GetFileAsync(fileName + ".txt");

                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, text);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Oh noes! An error occurred with file writing " + ex.Message);
            }
        }

        // delete an existing file
        public async void DeleteFile(string fileName)
        {
            try
            {
                Windows.Storage.StorageFile sampleFile =
                    await textfileFolder.GetFileAsync(fileName + ".txt");

                await sampleFile.DeleteAsync();
            }
            catch(FileNotFoundException ex)
            {
                Debug.WriteLine("Oh noes! An error occurred with file deleting " + ex.Message);
            }
        }


    }
}