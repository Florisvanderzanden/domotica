using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
using System.Windows.Forms;

namespace domotica
{
    public class SpeechToText
    {
        DictationGrammar dictation;
        SpeechRecognitionEngine sr;
        RichTextBox textBox;

        public void getVoice()
        {
            try
            {
                textBox.Text = "";
                dictation = new DictationGrammar();
                sr = new SpeechRecognitionEngine();
                sr.LoadGrammar(dictation);

                sr.SetInputToDefaultAudioDevice();

                sr.RecognizeAsync(RecognizeMode.Multiple);

                //sr.SpeechHypothesized -= new EventHandler<SpeechHypothesizedEventArgs>(SpeechHypothesizing);
                sr.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);
                sr.EmulateRecognizeCompleted -= new EventHandler<EmulateRecognizeCompletedEventArgs>(EmulateRecognizeCompletedHandler);

                //sr.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(SpeechHypothesizing);
                sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);
                sr.EmulateRecognizeCompleted += new EventHandler<EmulateRecognizeCompletedEventArgs>(EmulateRecognizeCompletedHandler);
            }
            catch
            {

            }
        }

        string finalResult;
        private void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                finalResult = e.Result.Text;
                textBox.Text += " " + finalResult;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool isCompleted = false;
        private void EmulateRecognizeCompletedHandler(object sender, EmulateRecognizeCompletedEventArgs e)
        {
            try
            {
                isCompleted = true;

                sr.UnloadGrammar(dictation);
                sr.RecognizeAsyncStop();

                textBox.Text += "\n\nCompleted. \n";
                MessageBox.Show("Completed. ");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public SpeechToText( RichTextBox aTextBox )
        {
            textBox = aTextBox;
        }
    }
}