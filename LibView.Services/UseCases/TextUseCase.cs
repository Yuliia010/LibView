using LibView.DAL.Models;
using LibView.DAL.Repositories;
using LibView.DAL;
using LibView.Domain.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibView.Domain.UseCases
{
    public class TextUseCase
    {
        static private LibViewContext _context = new LibViewContext();
        static private Repository<Text> _repository = new Repository<Text>(_context);
        static private TextProvider _provider = new TextProvider(_repository);
        static private List<Text> _texts => _provider.GetTexts().ToList();

        static public void Add(Text text)
        {
            _provider.AddText(text);
        }

        static public Text GetText(int id)
        {
            foreach (var text in _texts)
            {
                if (text.Id == id)
                {
                    return text;
                }
            }
            return null;
        }

        static public List<Text> GetTextIdFromName(string textName)
        {
            List<Text> result = new List<Text>();
            foreach (var text in _texts)
            {
                if (text.Name == textName)
                {
                    result.Add(text);
                }
            }
            return null;
        }

        static public void DeleteText(int id)
        {
            _provider.RemoveText(id);

        }
        static public List<Text> GetAllTexts()
        {
            return _texts.ToList();
        }

        static public string GetTextName(int id)
        {
            return _provider.GetText(id).Name;
        }

        static public void Update(Text text)
        {
            var existingText = _context.Texts.FirstOrDefault(t => t.Id == text.Id);

            if (existingText != null)
            {
                existingText.Name = text.Name;
                existingText.Description = text.Description;
                existingText.EngText = text.EngText;
                existingText.TranslText = text.TranslText;
                existingText.Image = text.Image;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Text wasn't found!");
            }
        }
    }
}
