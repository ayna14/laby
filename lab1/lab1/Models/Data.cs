using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace lab1.Models
{
    public class Data
    {
        public static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "book");
        public static List<Notepad> NoteList;
        public string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Content\");

        //сохранение данных в файле в Jsonформат
        public void AddNotepad(string N)
        {
            var text = File.ReadAllText(filePath);
            NoteList = JsonConvert.DeserializeObject<List<Notepad>>(text);

            NoteList.Add(new Notepad(N));
            WriteFile();
        }
        public  void WriteFile() 
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(NoteList));
        }

        public  List<Notepad> LoadNotes()
        {
            if (NoteList == null) { NoteList = new List<Notepad>(); }

            var text = File.ReadAllText(filePath);

            NoteList = JsonConvert.DeserializeObject<List<Notepad>>(text);

            return NoteList;
        }


        public void SetContent(string name, string con)
        {
            var n = NoteList.FirstOrDefault(notepad => notepad.Name == name);
            if (n != null)
            {
                n.Content = con;
                WriteFile();
            }
        }

        public string GetContent(string name)
        {
            var n = NoteList.FirstOrDefault(notepad => notepad.Name == name);
            if (n != null)
            {
                return n.Content;
            }
            else { return ""; }
        }

        public void CreateImage(string nameNotepad)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            int width = 0;
            int height = 0;
            
            Font font = new Font("Impact", 30, FontStyle.Bold, GraphicsUnit.Pixel);
            
            Graphics graphics = Graphics.FromImage(bitmap);
            
            width = (int)graphics.MeasureString(nameNotepad, font).Width;
            height = (int)graphics.MeasureString(nameNotepad, font).Height;
            
            bitmap = new Bitmap(bitmap, new Size(width, height));
            
            graphics = Graphics.FromImage(bitmap);
            
            graphics.Clear(Color.White);
            
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            
            graphics.DrawString(nameNotepad, font, new SolidBrush(Color.Blue), 0, 0);
            graphics.Flush();

            bitmap.Save(imagePath + nameNotepad + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}