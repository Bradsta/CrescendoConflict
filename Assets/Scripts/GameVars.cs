using UnityEngine;

static class GameVars {
    //stores game values that need to be presistant between scenes

    public enum Avitar { DOM, TING, PLINK, MANA }

    public static int PlayerCount = 4;
    public static Avitar[] Avitars = { Avitar.DOM, Avitar.TING, Avitar.PLINK, Avitar.MANA };
    //COLORS HARDCODED HERE!!!!!!!!!!!!!!
    readonly public static Color[] Colors = { new Color(68/255f, 137/255f, 26/255f),
                                     new Color(190/255f, 38/255f, 51/255f),
                                     new Color(0, 87/255f, 132/255f),
                                     new Color(235/255f, 137/255f, 49/255f) };

}
