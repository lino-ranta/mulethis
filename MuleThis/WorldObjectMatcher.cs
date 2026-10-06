using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System.Collections.Generic;

public interface WorldObjectMatcher
{
    bool IsMatch(WorldObject wo);
}

public class ObjectClassWorldObjectMatcher : WorldObjectMatcher
{
    private ObjectClass objectClass;
    public ObjectClassWorldObjectMatcher(ObjectClass oc)
    {
        this.objectClass = oc;
    }

    public bool IsMatch(WorldObject wo)
    {
        return wo.ObjectClass == this.objectClass;
    }
}

public class AccessoryWorldObjectMatcher : WorldObjectMatcher
{

    public static string ANY_JEWELRY = "<any Jewelry>";
    public static string ANY_CLOTHES = "<any Underwear>";

    private List<int> Includes;
    public AccessoryWorldObjectMatcher(string accsSelector)
    {
        this.Includes = new List<int>();

        bool all = accsSelector.Equals("<any>");
        bool allJewels = all || accsSelector.Equals(ANY_JEWELRY);
        bool allUnderwear = all || accsSelector.Equals(ANY_CLOTHES);

        if (allJewels || accsSelector.Contains("Bracelet"))
        {
            this.Includes.Add(196608);
        }
        if (allJewels || accsSelector.Contains("Necklace"))
        {
            this.Includes.Add(32768);
        }
        if (allJewels || accsSelector.Contains("Ring"))
        {
            this.Includes.Add(786432);
        }
        if (allJewels || accsSelector.Contains("Trinket"))
        {
            this.Includes.Add(67108864); 
        }

        if (allUnderwear || accsSelector.Contains("Pants"))
        {
            this.Includes.Add(196);
        }
        if (allUnderwear || accsSelector.Contains("Shirt"))
        {
            this.Includes.Add(30);
        }
    }

    public bool IsMatch(WorldObject wo)
    {
        if (this.Includes.Count == 0) { return false; }

        return this.Includes.Contains(wo.Values(LongValueKey.EquipableSlots, 0));
    }

}