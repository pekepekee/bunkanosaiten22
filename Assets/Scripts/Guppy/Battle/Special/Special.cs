using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Battle
{
    public enum SpecialMovieState
    {
        IDLE,
        START,
        PLAYING,
        FINISH
    }

    public class Special : MonoBehaviour
    {
        [SerializeField] private SpecialMovie specialMovie;
        [SerializeField] private SpecialEffect[] specialEffects;

        private SpecialMovieState movieState = SpecialMovieState.IDLE;

        void Update()
        {
            if(movieState == SpecialMovieState.START)
            {
                PlayMovie();
                movieState = SpecialMovieState.PLAYING;
            }
            else if(movieState == SpecialMovieState.PLAYING)
            {
                if (specialMovie.playing == false)
                {
                    ExecuteSkill();
                    movieState = SpecialMovieState.FINISH;
                }
            }
        }

        public void Execute()
        {
            movieState = SpecialMovieState.START;
        }

        private void ExecuteSkill()
        {
            foreach (SpecialEffect effect in specialEffects)
            {
                effect.Execute();
            }
        }

        private void PlayMovie()
        {
            specialMovie.Play();
        }

        public bool IsMoviePlaying()
        {
            return movieState == SpecialMovieState.PLAYING || movieState == SpecialMovieState.START;
        }
    }
}
