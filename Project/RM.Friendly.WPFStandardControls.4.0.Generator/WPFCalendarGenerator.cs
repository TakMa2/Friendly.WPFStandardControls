﻿using System;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Windows.Controls;

namespace RM.Friendly.WPFStandardControls.Generator
{
    [CaptureCodeGenerator("RM.Friendly.WPFStandardControls.WPFCalendar")]
    public class WPFCalendarGenerator : CaptureCodeGeneratorBase
    {
        Calendar _control;

        protected override void Attach()
        {
            _control = (Calendar)ControlObject;
            _control.SelectedDatesChanged += SelectedDatesChanged;
        }

        protected override void Detach()
        {
            _control.SelectedDatesChanged -= SelectedDatesChanged;
        }

        void SelectedDatesChanged(object sender, EventArgs e)
        {
            if (_control.SelectedDate != null)
            {
                DateTime day = _control.SelectedDate.Value;
                AddSentence(new TokenName(), ".EmulateChangeDate(new DateTime(", day.Year, ", ", day.Month, ", ", day.Day, ")", new TokenAsync(CommaType.Before), ");");
            }
        }
    }
}
