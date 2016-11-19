﻿using UnityEngine;
using System.Collections;

namespace UnityEngine
{
    public static class ParticleExtensions
    {

        /// <summary>
        /// Enables the particle system to emit.
        /// </summary>
        /// <param name="particleSystem">The particle system.</param>
        /// <param name="enabled">If set to <c>true</c> emission will be enabled.</param>
        public static void EnableEmission(this ParticleSystem particleSystem, bool enabled)
        {
            var emission = particleSystem.emission;
            emission.enabled = enabled;
        }

        /// <summary>
        /// Gets the emission rate.
        /// </summary>
        /// <returns>The emission rate.</returns>
        /// <param name="particleSystem">Particle system.</param>
        public static float GetEmissionRate(this ParticleSystem particleSystem)
        {
            return particleSystem.emission.rate.constantMax;
        }

        /// <summary>
        /// Sets the emission rate.
        /// </summary>
        /// <param name="particleSystem">Particle system.</param>
        /// <param name="emissionRate">Emission rate.</param>
        public static void SetEmissionRate(this ParticleSystem particleSystem, float emissionRate)
        {
            var emission = particleSystem.emission;
            var rate = emission.rate;
            rate.constantMax = emissionRate;
            emission.rate = rate;
        }
    }

}
