﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Method)]
public class EventHandlerAttribute : Attribute
{
	public EventHandlerAttribute() { }
}