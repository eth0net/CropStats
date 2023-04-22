using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CropStats;

public class CropStatsComp : ThingComp
{
    public float Efficiency { get; private set; }

    /// <summary>
    /// Initialize the comp by calculating crop efficiency.
    /// </summary>
    public override void Initialize(CompProperties initProps)
    {
        base.Initialize(initProps);

        var nutrition = parent.def.statBases.FirstOrDefault(stat => stat.stat == StatDefOf.Nutrition).value;
        var yield = parent.def.plant.harvestYield;
        var days = parent.def.plant.growDays;

        Efficiency = (yield * nutrition) / days;
    }

    /// <summary>
    /// SpecialDisplayStats adds to the item info pane.
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<StatDrawEntry> SpecialDisplayStats()
    {
        yield return new StatDrawEntry(StatCategoryDefOf.Basics, "Efficiency".Translate(), Efficiency.ToStringSafe(),
            "EfficiencyDesc".Translate(), 1000);
    }
}