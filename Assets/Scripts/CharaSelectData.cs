using System;

/// <summary>
/// 選択されたキャラクターの情報
/// </summary>
public sealed class CharaSelectData : IEquatable<CharaSelectData>
{
    private readonly Characters player1Chara;

    public Characters Player1Chara => player1Chara;

    private readonly Characters player2Chara;

    public Characters Player2Chara => player2Chara;

    public CharaSelectData(Characters player1Chara, Characters player2Chara)
    {
        this.player1Chara = player1Chara;
        this.player2Chara = player2Chara;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as CharaSelectData);
    }

    public bool Equals(CharaSelectData other)
    {
        return other != null &&
               player1Chara == other.player1Chara &&
               player2Chara == other.player2Chara;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(player1Chara, player2Chara);
    }
}
