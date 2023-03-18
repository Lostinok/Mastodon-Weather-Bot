using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostinOK.Mastodon_Weather_Bot.Kernel.Entities.WeatherAPI
{
    public class WeatherAPIResult<T>
    {
        public DateTime? ExpirationDate { get; set; }
        public T? Value { get; set; }
    }
}
