using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CropStats;

public class CropStatsDef : ThingDef
{
    public float Efficiency => this.CropEfficiency();

    public override IEnumerable<StatDrawEntry> SpecialDisplayStats(StatRequest req)
    {
        foreach (var stat in base.SpecialDisplayStats(req))
        {
            yield return stat;
        }

        yield return new StatDrawEntry(StatCategoryDefOf.Basics, "Efficiency".Translate(), Efficiency.ToStringSafe(),
            "EfficiencyDesc".Translate(), 1000);
    }
}