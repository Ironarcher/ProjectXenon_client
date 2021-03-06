﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curry_Server
{
    [Serializable]
    class Question
    {
        private String prompt;
        private String AnswerA;
        private String AnswerB;
        private String AnswerC;
        private String AnswerD;
        private char chosenAnswer;
        private char correctAnswer;
        //Multiple Choice Only
        public Question(String tprompt, String aa, String ab, String ac, String ad, char correctanswer)
        {
            prompt = tprompt;
            AnswerA = aa;
            AnswerB = ab;
            AnswerC = ac;
            AnswerD = ad;
            correctAnswer = correctanswer;
            chosenAnswer = '0';
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
        public char getCorrectAnswer()
        {
            return correctAnswer;
        }
        public char getChosenAnswer()
        {
            return chosenAnswer;
        }
    }
    [Serializable]
    class Mission
    {
        public Mission(EnumMission mtype)
        {
            this.type = mtype;
        }
        public Mission() { }
        public int xpreward = 0;
        public int goldreward = 0;
        public DateTime missionStart, missionEnd;
        public int lvlStartEligible, lvlEndEligible;
        public EnumMission type;
        public String title;
        public List<Question> questions;
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
