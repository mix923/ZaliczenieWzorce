using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryButton 
{
    public abstract Button CreateButton();
}

public class FactorySquareButton : FactoryButton
{
    public override Button CreateButton()
    {
        return new SquareButton();
    }
}

public class FactoryCircleButton : FactoryButton
{
    public override Button CreateButton()
    {
        return new CircleButton();
    }
}


public abstract class Button
{
    public abstract string GetImage();
}

public class SquareButton : Button
{
    public override string GetImage()
    {
        return "Square";
    }
}

public class CircleButton : Button
{
    public override string GetImage()
    {
        return "Circle";
    }
}
