using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls
{

    public abstract class Wall
    {
        public abstract int HP { get; }
        //GameObject?
        //Material
    }

    public class WoodWall : Wall
    {
        public override int HP => 1;
        //GameObject?
        //Material
    }

    public class ClayWall : Wall
    {
        public override int HP => 2;
        //GameObject?
        //Material
    }

    public class MetalWall : Wall
    {
        public override int HP => 3;
        //GameObject?
        //Material
    }

    public class AbstractWall
    {
       /* public Wall GetWall(string wallType)
        {
            Find factory or specific wall and return the health, gameobject and materials. Probably gonna return through to a shooting hit detection script (non existant)
            and make it go if pellet collide col to a wall here. hp - 1, and after that, if hp <=0, destroy object. yea no time i hate this. im sick. 
        }*/
    }
}
