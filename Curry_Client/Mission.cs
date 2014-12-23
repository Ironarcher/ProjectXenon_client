using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curry_Client
{
    class Question
    {
        private String prompt;
        private String AnswerA;
        private String AnswerB;
        private String AnswerC;
        private String AnswerD;
        private char chosenAnswer;
        private int correctAnswer;
        //Multiple Choice Only
        public Question(String tprompt, String aa, String ab, String ac, String ad, int correctanswer)
        {
            prompt = tprompt;
            AnswerA = aa;
            AnswerB = ab;
            AnswerC = ac;
            AnswerD = ad;
            correctAnswer = correctanswer;
        }
        public String getPrompt()
        {
            return prompt;
        }
        public String[] getAnswers()
        {
            return new String[] { AnswerA, AnswerB, AnswerC, AnswerD };
        }
        public void selectAnswer(String answer)
        {
            if (answer == AnswerA)
            {
                chosenAnswer = 'a';
            }
            else if (answer == AnswerB)
            {
                chosenAnswer = 'b';
            }
            else if (answer == AnswerC)
            {
                chosenAnswer = 'c';
            }
            else if (answer == AnswerD)
            {
                chosenAnswer = 'd';
            }
        }
    }
    class Mission
    {
        public int xpreward = 0;
        public Mission(EnumMission mtype)
        {
            this.type = mtype;
        }
        public EnumMission type;
        public String title;
        public Question[] questions;
        public bool AutoGrade
        {
            get { return this.type == EnumMission.MultipleChoice; }
        }

        public void randomize()
        {

        }
    }
    enum EnumMission
    {
        MultipleChoice, FreeResponse, FileUpload, Text
    }
}
