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
    internal class WalkingRightPlayerState : AbstractPlayerState
    {
        public WalkingRightPlayerState(PlayerCharacter player) : base(player)
        {
            sprite = new WalkingRightWizardSprite();
        }
        public override void Update()
        {
            base.Update();

            if (MyKeyboard.IsKeyDown(Keys.D))
                player.x += player.speed;
            else if (MyKeyboard.WasKeyPressed(Keys.A))
                player.state = new WalkingLeftPlayerState(player);
            else
                player.state = new IdlePlayerState(player);
        }
    }
}
