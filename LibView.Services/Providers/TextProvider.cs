using LibView.DAL.Models;
using LibView.DAL.Repositories;
namespace LibView.Domain.Providers
{
    internal class TextProvider
    {
        private readonly IRepository<Text> _textRepository;


        internal TextProvider(IRepository<Text> repository)
        {
            _textRepository = repository;
        }

        internal void AddTexts(List<Text> texts)
        {
            foreach (var text in texts)
            {
                AddText(text);
            }
        }

        internal void AddText(Text text)
        {
            _textRepository.Add(text);
        }

        internal Text GetText(int id)
        {
            return _textRepository.Get(id);
        }

        internal IEnumerable<Text> GetTexts()
        {
            return _textRepository.GetAll();
        }

        internal void RemoveText(int id)
        {
            var text = GetText(id);
            _textRepository.Remove(text);
        }
    }
}
