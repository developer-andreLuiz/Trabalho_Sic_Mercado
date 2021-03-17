using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Mercado.ModelAzure;

namespace Mercado.Funcoes
{
    class BlobStorageHelper
    {
        private static CloudBlobContainer ObterReferenciaConteiner(string nomeConteiner)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(nomeConteiner);
        }
        private static CloudBlockBlob ObterReferenciaBlockBlob(string nomeContainer, string nomeBlob)
        {
            CloudBlobContainer container = ObterReferenciaConteiner(nomeContainer);
            return container.GetBlockBlobReference(nomeBlob);
        }
        public static void CheckContainer(string nomeContainer)
        {
            CloudBlobContainer container = ObterReferenciaConteiner(nomeContainer);
            container.CreateIfNotExists();
        }
        public static List<ImgAzure> ListBlockBlobs(string nomeContainer)
        {
            List<ImgAzure> blobs = new List<ImgAzure>();
            CloudBlobContainer container = ObterReferenciaConteiner(nomeContainer);

            foreach (var blob in container.ListBlobs())
            {
                if (blob is CloudBlockBlob)
                {
                    ImgAzure img = new ImgAzure();
                    img.nome = ((CloudBlockBlob)blob).Name;
                    img.url = ((CloudBlockBlob)blob).StorageUri.PrimaryUri.ToString();
                    img.datahora = ((CloudBlockBlob)blob).Properties.Created.Value.DateTime;
                    blobs.Add(img);
                }
            }
            return blobs;
        }
        public static void UploadBlockBlob(string nomeContainer, string nomeBlob, string nomeArquivo)
        {
            CloudBlockBlob blob = ObterReferenciaBlockBlob(nomeContainer, nomeBlob);
            blob.UploadFromFile(nomeArquivo);

        }
        public static void DownloadBlockBlob(string nomeContainer, string nomeBlob, string nomeArquivo)
        {
            CloudBlockBlob blob = ObterReferenciaBlockBlob(nomeContainer, nomeBlob);
            blob.DownloadToFile(nomeArquivo, FileMode.CreateNew);

        }
        public static void DeleteBlockBlob(string nomeContainer, string nomeBlob)
        {
            CloudBlockBlob blob = ObterReferenciaBlockBlob(nomeContainer, nomeBlob);
            blob.Delete();

        }
    }
}
