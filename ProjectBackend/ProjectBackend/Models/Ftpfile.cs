﻿using System;
using System.Collections.Generic;

namespace ProjectBackend.Models;

public partial class Ftpfile
{
    public int Id { get; set; }

    public string File { get; set; } = null!;

    public DateTime Timestamp { get; set; }
}