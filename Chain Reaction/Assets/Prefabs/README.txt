If you want something to be affected by an explosion, make sure it has:
1. A collider
2. The collider's gameobject's Layer set to Explodeable
3. An monobehaviour that implements IExplodeable (such as pirate, barrel, etc.)