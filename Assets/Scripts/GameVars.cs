using UnityEngine;

static class GameVars {
    //stores game values that need to be persistent between scenes

    public enum Avatar { DOM, TING, PLINK, MANA }

    public static int PlayerCount = 1;
    public static Avatar[] Avatars = { Avatar.DOM, Avatar.TING, Avatar.PLINK, Avatar.MANA };
    //COLORS HARDCODED HERE!!!!!!!!!!!!!!
    readonly public static Color[] Colors = { new Color(68/255f, 137/255f, 26/255f),
                                     new Color(190/255f, 38/255f, 51/255f),
                                     new Color(0, 87/255f, 132/255f),
                                     new Color(235/255f, 137/255f, 49/255f) };

}
