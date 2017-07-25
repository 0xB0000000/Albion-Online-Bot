﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Merlin
{
	public static class HarvestableObjectViewExtensions
	{
		static HarvestableObjectViewExtensions()
		{

		}

		public static int GetTier(this HarvestableObjectView instance)
		{
			return instance.HarvestableObject.sm();
		}

		public static int GetRareState(this HarvestableObjectView instance)
		{
			return instance.HarvestableObject.sp();
		}

		public static int GetCurrentCharges(this HarvestableObjectView instance)
		{
			return (int)instance.HarvestableObject.sl();
		}

		public static long GetMaxCharges(this HarvestableObjectView instance)
		{
			return instance.HarvestableObject.sr();
		}

		public static bool IsLootProtected(this HarvestableObjectView instance)
		{
			return !instance.HarvestableObject.st();
		}

		public static bool CanLoot(this HarvestableObjectView instance, LocalPlayerCharacterView player)
		{
			if (instance.IsLootProtected())
				return false;

			var tool = instance.GetTool(player);

			if (tool == null && instance.RequiresTool())
				return false;

			return true;
		}

		public static apu GetTool(this HarvestableObjectView instance, LocalPlayerCharacterView player)
		{
			return instance.HarvestableObject.v(player.LocalPlayerCharacter, true);
		}

		public static bool RequiresTool(this HarvestableObjectView instance)
		{
			return instance.HarvestableObject.sg().ak();
		}
	}
}