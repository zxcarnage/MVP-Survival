using System;
using System.Collections.Generic;
using Game.Collectable;
using UniRx;

namespace Game.Player.Models
{
    public class ToolsModel
    {
        private readonly Dictionary<int,EToolType> _toolsUnlocked = new();
        public ReactiveProperty<EToolType> ActiveTool { get; } = new(EToolType.Pickaxe);

        public void Unlock(EToolType type)
        {
            if (_toolsUnlocked.ContainsKey((int)type))
                return;
            _toolsUnlocked.Add((int)type, type);
        }
        
        public void TryChangeActiveTool()
        {
            if (_toolsUnlocked.Count != 1) 
                ActiveTool.Value = NextListTool();
        }

        private EToolType NextListTool()
        {
            var targetIndex = (int)ActiveTool.Value;
            return _toolsUnlocked.ContainsKey(targetIndex + 1) ? _toolsUnlocked[targetIndex + 1] : _toolsUnlocked[1];
        }
    }
}