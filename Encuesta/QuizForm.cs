using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encuesta.Models.Dto;
using Encuesta.Services;

namespace Encuesta
{
    public partial class QuizForm : Form
    {
        private QuizServices _quizService = new QuizServices();
        private QuizDto _quiz = null;
        public QuizForm()
        {
            InitializeComponent();
            _quiz = _quizService.GetQuiz();
        }

        public QuizForm(int quizId) : this()
        {
            _quiz = _quizService.GetQuiz(quizId);
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            txtQuizName.Text = _quiz.Name;
            ReloadDataGrid();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            using (Nueva_pregunta form = new Nueva_pregunta())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        _quizService.AddQuestionToQuiz(_quiz, form.GetNewQuestion());
                        ReloadDataGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        void ReloadDataGrid()
        {
            dgQuestions.DataSource = _quiz.Questions.ToList();
            dgQuestions.Columns[0].HeaderText = "Pregunta";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.SetMainPanelForm(new QuizMainView());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _quiz.Name = txtQuizName.Text;
            _quizService.SaveQuiz(_quiz);
        }
    }
}
