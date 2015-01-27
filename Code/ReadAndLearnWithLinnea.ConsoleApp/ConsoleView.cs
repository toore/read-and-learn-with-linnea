using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.ConsoleApp
{
    public class ConsoleView : IConsumer
    {
        public void SelectPractise(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer)
        {
            WriteTitle("Select vocabulary to practise?");

            var vocabulariesClosure = vocabularies.ToList();
            for (int i = 0; i < vocabulariesClosure.Count; i++)
            {
                var vocabulary = vocabulariesClosure[i];

                Console.WriteLine(i + "\t" + vocabulary.Name + "\t" + vocabulary.Vocables.Count());
            }

            var selectedIndex = GetSelectedIndex(vocabulariesClosure.Count);

            practiseInitializer.Start(vocabulariesClosure[selectedIndex]);
        }

        public void NewPractise(IModerator moderator, IQuestion question)
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

        public void PractiseCompleted(string name, int noOfCorrectAnswers, int noOfQuestions, Action continueWith)
        {
            WriteTitle(
                string.Format("Practies of {1} completed!{0}{0}You passed {2} of {3} ({4:P0}).",
                Environment.NewLine,
                name,
                noOfCorrectAnswers,
                noOfQuestions,
                noOfCorrectAnswers / (double)noOfQuestions));

            Console.ReadKey(true);
            continueWith.Invoke();
        }

        private static void WriteTitle(string title)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(title);
            Console.ResetColor();
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