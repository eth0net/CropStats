using System.Collections.Generic;
using RimWorld;
using Verse;

namespace CropStats;

public class CropStatsDef : ThingDef
{
    private float? _cachedEfficiency;

    public float Efficiency => _cachedEfficiency ??= CropEfficiency();

    private float CropEfficiency()
    {
        var nutrition = plant.harvestedThingDef.statBases.FirstOrDefault(stat => stat.stat == StatDefOf.Nutrition);
        return plant.harvestYield * nutrition.value / plant.growDays;
    }

    public override IEnumerable<StatDrawEntry> SpecialDisplayStats(StatRequest req)
    {
        foreach (var stat in base.SpecialDisplayStats(req))
        {
            yield return stat;
        }

        yield return new StatDrawEntry(
            StatCategoryDefOf.Basics,
            "Efficiency".Translate(),
            Efficiency.ToString("0.00"),
            "EfficiencyDesc".Translate(),
            1000
        );
    }
}