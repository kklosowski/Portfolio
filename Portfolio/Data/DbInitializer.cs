﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Models;

namespace Portfolio.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Projects.Any())
            {
                applicationDbContext.AddRange
                (
                    new Project() {Title = "RoundCalc", ShortDescription = "RoundCalc is a ergonomic calculator for Android Wear Devices.", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla efficitur faucibus molestie. Phasellus et lorem id ante viverra mattis eu sed erat. Nunc viverra eget quam sit amet tempor. Phasellus porta tortor sed sapien tempus placerat. Sed pellentesque aliquam arcu, in euismod dolor malesuada ac. Pellentesque ipsum purus, pulvinar a malesuada non, accumsan ac est. Nam egestas libero ut eros elementum finibus. Cras eleifend, diam eget hendrerit congue, mi augue fermentum odio, nec rhoncus lectus diam sit amet leo. Maecenas ac ex sit amet ante commodo commodo et quis enim. Etiam finibus, nulla nec vulputate luctus, orci felis aliquet sapien, sed congue lorem tortor non leo. Curabitur ultrices enim ex, a viverra ante ullamcorper ac. Pellentesque vulputate faucibus lectus in scelerisque.", ImageThumbnailUrl = "https://github.com/kklosowski/RoundCalc/raw/master/img/round_calc_icon_min.png", ImageUrl = "https://github.com/kklosowski/RoundCalc/raw/master/img/round_calc_icon_min.png", GithubUrl = "https://github.com/kklosowski/RoundCalc" }    


                );
            }
        }
    }
}
