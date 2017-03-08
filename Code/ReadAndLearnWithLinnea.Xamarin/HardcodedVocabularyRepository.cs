using System.Collections.Generic;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.Core.Tools
{
    public class HardcodedVocabularyRepository : IVocabularyRepository
    {
        public IEnumerable<IVocabulary> GetAll()
        {
            yield return new Vocabulary("FURNITURE",
                new List<Vocable>
                    {
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "furniture"),
                                new Word(Language.Swedish, "möbler")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "sofa"),
                                new Word(Language.Swedish, "soffa")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "table"),
                                new Word(Language.Swedish, "bord")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "curtain"),
                                new Word(Language.Swedish, "gardin")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "bookshelf"),
                                new Word(Language.Swedish, "bokhylla")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "chair"),
                                new Word(Language.Swedish, "stol")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "bed"),
                                new Word(Language.Swedish, "säng")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "drawer"),
                                new Word(Language.Swedish, "byrå")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "carpet"),
                                new Word(Language.Swedish, "matta")
                            })
                    });

            yield return new Vocabulary("Fruits",
                new List<Vocable>
                    {
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "Apple"),
                                new Word(Language.Swedish, "Äpple")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "Pineapple"),
                                new Word(Language.Swedish, "Ananas")
                            }),
                        new Vocable(new List<Word>
                            {
                                new Word(Language.English, "Banana"),
                                new Word(Language.Swedish, "Banan")
                            })
                    });
        }
    }
}