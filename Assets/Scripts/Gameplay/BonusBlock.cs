using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    
    internal class BonusBlock : Block
    {
        int bonusPoints = 500;
        

   
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            Sprite actualSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

            if (actualSprite.name == "Amarelo-Velocidade") { MudarVelocidade(2f, 3); }
            else if (actualSprite.name == "Azul-Congelar") { MudarVelocidade(0.5f, 3); }

            EventBlock.Invoke(bonusPoints);
            Destroy(gameObject);

            
            
        }

        public void MudarVelocidade(float boost, int time)
        {
            if (boost != 0)
            {
                GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().changeVelocity(boost);
            }

        } 
  
    }

}
