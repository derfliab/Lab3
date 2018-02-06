﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
 * Andrea Derflinger
 * Lab 2 
 * 1/30/2018
 * This work and I comply with the JMU Honor Code.
**/
public class Skill
{
     
    string skillName;
    string skillDescription;
    string lastUpdatedBy;
    DateTime lastUpdated;

    public Skill(string skillName, string skillDescription, string lastUpdatedBy, DateTime lastUpdated)
    {
        SkillName = skillName;
        SkillDescription = skillDescription;
        LastUpdatedBy = lastUpdatedBy;
        LastUpdated = lastUpdated;
    }

    public string SkillName
    {
        get { return skillName; }
        private set { skillName = value; }
    }

    public string SkillDescription
    {
        get { return skillDescription; }
        private set { skillDescription = value; }
    }

    public string LastUpdatedBy
    {
        get { return lastUpdatedBy; }
        private set { lastUpdatedBy = value; }
    }

    public DateTime LastUpdated
    {
        get { return lastUpdated; }
        private set { lastUpdated = value; }
    }
}
