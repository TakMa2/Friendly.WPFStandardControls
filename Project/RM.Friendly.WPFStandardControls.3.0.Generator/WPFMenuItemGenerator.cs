﻿using System.Collections.Generic;
using System.Windows.Controls;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Windows;

namespace RM.Friendly.WPFStandardControls.Generator
{
    [Generator("RM.Friendly.WPFStandardControls.WPFMenuItem")]
    public class WPFMenuItemGenerator : GeneratorBase
    {
        MenuItem _control;
        delegate void DetachEvent();
        List<DetachEvent> _detach = new List<DetachEvent>();

        protected override void Attach()
        {
            _control = ControlObject as MenuItem;
            if (!string.IsNullOrEmpty(_control.Name))
            {
                _control.Click += Click;
            }
        }

        protected override void Detach()
        {
            _control.Click -= Click;
        }

        void Click(object sender, RoutedEventArgs e)
        {
            if (_control.Items.Count == 0)
            {
                AddSentence(new TokenName(), ".EmulateClick(", new TokenAsync(CommaType.Non), ");");
            }
        }
    }
}

