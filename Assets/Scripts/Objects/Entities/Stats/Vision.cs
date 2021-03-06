namespace Assets.Scripts.Objects.Entities.Stats {

    internal sealed class Vision : Stat {
        internal struct Default {
            internal record TerritoryExtra {
                internal const float Land = 0.0f;
                internal const float Air = 1.5f;
                internal const float Water = -1.0f;
            }
        }


        #region Helper

        internal float radius_byTerritory(Entity.Territory territory)
            => this.radius_base
            + territory switch {
                Entity.Territory.Water => Default.TerritoryExtra.Water,
                Entity.Territory.Air => Default.TerritoryExtra.Air,
                //? Entity.Territory.Land
                _ => Default.TerritoryExtra.Land
            };

        #endregion

        internal override StatName statName { get; }
        internal float radius_base { get; set; }
        internal Vision(float radius) {
            this.statName = StatName.Vision;
            this.radius_base = radius;
        }
    }
}
