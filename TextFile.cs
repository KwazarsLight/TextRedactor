using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redactor
{
    public enum eExtensions { txt, json, xml }

    public abstract class CustomFile 
    {
        protected string fileName;
        protected eExtensions fileExtension;
        protected byte[] fileContent;
        

        protected CustomFile(string fileName, eExtensions ext)
        {
            this.fileName = fileName;
            this.fileExtension = ext;
        }
        protected CustomFile(string fileName, eExtensions ext, byte[] FileContent)
        {
            this.fileName = fileName;
            this.fileExtension = ext;
            this.fileContent = FileContent;
        }

        public static eExtensions StringToeExtensions(string strExtension)
        {
            return (eExtensions)Enum.Parse(typeof(eExtensions), strExtension, true);
        }

       

    }

    public class TextFile : CustomFile
    {

        public string FileName { get { return fileName; } set { fileName = value; } }

        public eExtensions FileExtension { get {return fileExtension;} }

        public byte[] FileContent { get { return fileContent; } }

        public TextFile(string fileName, eExtensions ext) : base(fileName, ext)
        { }

        public TextFile(string fileName, eExtensions ext, byte[] FileContent) : base (fileName, ext, FileContent)
        { }

        public static implicit operator TextFile(FileInfo file)
        {
            try
            {
                TextFile textFile = new TextFile(file.Name, StringToeExtensions(file.Extension));
                return textFile;
            }
            catch (Exception ex) { return null; }
        }


    }


    public sealed class JsonFile : TextFile
    {
        public JsonFile(string fileName, eExtensions ext) : base(fileName, ext)
        { }

        public JsonFile(string fileName, eExtensions ext, byte[] FileContent) : base(fileName, ext, FileContent)
        { }
    }
}
