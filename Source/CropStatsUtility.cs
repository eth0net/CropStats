using RimWorld;
using Verse;

namespace CropStats;

public static class CropStatsUtility
{
    public static float CropEfficiency(this ThingDef def)
    {
        var nutrition = def.statBases.FirstOrDefault(stat => stat.stat == StatDefOf.Nutrition).value;
        return def.plant.harvestYield * nutrition / def.plant.growDays;
    }
}