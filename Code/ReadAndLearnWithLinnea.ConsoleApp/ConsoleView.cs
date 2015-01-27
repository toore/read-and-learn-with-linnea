using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.ConsoleApp
{
    public class ConsoleView : IConsumer
    {
        public void SelectVocabularyToPractise(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer)
        {
            WriteTitle("Select vocabulary to practise?");

            var vocabulariesClosure = vocabularies.ToList();
            for (int i = 0; i < vocabulariesClosure.Count; i++)
            {
                var vocabulary = vocabulariesClosure[i];

                Console.WriteLine(i + "\t" + vocabulary.Name + "\t" + vocabulary.Vocables.Count());
            }

            var selectedIndex = GetSelectedIndex(vocabulariesClosure.Count);

            practiseInitializer.StartPractise(vocabulariesClosure[selectedIndex]);
        }

        public void NewQuestion(IQuestion question, IModerator moderator)
        {
            WriteTitle("Translate: " + question.Text);

            var answers = question.Answers.ToList();
            for (int i = 0; i < answers.Count; i++)
            {
                var answer = answers[i];

                Console.WriteLine(i + "\t" + answer);
            }

            var selectedIndex = GetSelectedIndex(answers.Count);

            moderator.Answer(question, answers[selectedIndex]);
        }

        public void PractiseCompleted(string name, IScore score, Action continueWith)
        {
            WriteTitle(string.Format("Practies of {0} completed!", name));

            Console.WriteLine(
                "You passed {0} of {1} ({2:P0}).",
                score.NoOfCorrectAnswers,
                score.NoOfQuestions,
                score.PercentageCompleted);

            Console.ReadKey(true);

            continueWith.Invoke();
        }

        private static void WriteTitle(string title)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(title);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        private static int GetSelectedIndex(int max)
        {
            var selectedIndex = -1;
            while (selectedIndex < 0 || selectedIndex >= max)
            {
                var consoleKeyInfo = Console.ReadKey(true);
                int.TryParse(consoleKeyInfo.KeyChar.ToString(CultureInfo.InvariantCulture), out selectedIndex);
            }

            return selectedIndex;
        }
    }
}