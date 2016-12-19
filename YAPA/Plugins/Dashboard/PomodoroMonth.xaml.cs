﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace YAPA.Plugins.Dashboard
{
    public partial class PomodoroMonth : UserControl
    {
        private IEnumerable<PomodoroViewModel> _month;
        public PomodoroMonth(IEnumerable<PomodoroViewModel> month = null)
        {
            _month = month;
            Loaded += PomodoroMonth_Loaded;
            InitializeComponent();
        }

        private void PomodoroMonth_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_month == null)
            {
                return;
            }

            MonthName.Text = _month.First().DateTime.ToString("MMMM");

            var weeks = _month.GroupBy(x => x.Week).ToList();
            foreach (var week in weeks)
            {
                PomodorWeeks.Children.Add(new PomodoroWeek(week));
            }

            PomodorWeeks.Width = weeks.Count() * 13;
        }
    }
}
