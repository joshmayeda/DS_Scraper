using DS_Scraper;
public class Shield
{
    public string? ImageURL { get; set; }
    public string? Name { get; set; }
    public int AttackPower { get; set; }
    public int PhysicalDamageReductionPercent { get; set; }
    public int MagicAttackPower { get; set; }
    public int MagicDamageReductionPercent { get; set; }
    public int FireAttackPower { get; set; }
    public int FireDamageReductionPercent { get; set; }
    public int LightningAttackPower { get; set; }
    public int LightningDamageReductionPercent { get; set; }
    public int CriticalAttackPower { get; set; }
    public int Stability { get; set; }
    public int RequiredStrength { get; set; }
    public String? MaxStrengthScaling { get; set; }
    public int RequiredDexterity { get; set; }
    public String? MaxDexterityScaling { get; set; }
    public int RequiredIntelligence { get; set; }
    public String? MaxIntelligenceScaling { get; set; }
    public int RequiredFaith { get; set; }
    public String? MaxFaithScaling { get; set; }
    public int Durability { get; set; }
    public double Weight { get; set; }
    public String? Deflection { get; set; }
    public String? ParrySpeed { get; set; }
    public String? AcquiredFrom { get; set;}
    public String? Description { get; set; }
}
