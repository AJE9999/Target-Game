using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.Sprites;
using Untitled_Project.Sprites.Blocks;

namespace Untitled_Project.Player.PlayerStates
{
    internal class IdlePlayerState : AbstractPlayerState
    {
        public IdlePlayerState(PlayerCharacter player) : base(player)
        {
            sprite = new StandingWizardSprite();
        }

        public override void Update()
        {
            base.Update();

            if (MyKeyboard.WasKeyPressed(Keys.D))
                player.state = new WalkingRightPlayerState(player);
            else if (MyKeyboard.WasKeyPressed(Keys.A))
                player.state = new WalkingLeftPlayerState(player);
        }
    }
}
