﻿// <copyright file="ObjTriplet.cs" company="Jérémy Ansel">
// Copyright (c) 2017, 2019 Jérémy Ansel
// </copyright>
// <license>
// Licensed under the MIT license. See LICENSE.txt
// </license>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace JeremyAnsel.Media.WavefrontObj
{
    public struct ObjTriplet : IEquatable<ObjTriplet>
    {
        private int vertex;

        private int texture;

        private int normal;

        public ObjTriplet(int vertexIndex, int textureIndex, int normalIndex)
        {
            this.vertex = vertexIndex;
            this.texture = textureIndex;
            this.normal = normalIndex;
        }

        public int Vertex
        {
            get { return this.vertex; }
            set { this.vertex = value; }
        }

        public int Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public int Normal
        {
            get { return this.normal; }
            set { this.normal = value; }
        }

        public override bool Equals(object obj)
        {
            return obj is ObjTriplet triplet && Equals(triplet);
        }

        public bool Equals(ObjTriplet other)
        {
            return vertex == other.vertex &&
                   texture == other.texture &&
                   normal == other.normal;
        }

        public override int GetHashCode()
        {
            var hashCode = -683219715;
            hashCode = hashCode * -1521134295 + vertex.GetHashCode();
            hashCode = hashCode * -1521134295 + texture.GetHashCode();
            hashCode = hashCode * -1521134295 + normal.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            if (this.Normal == 0)
            {
                if (this.Texture == 0)
                {
                    return this.Vertex.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    return string.Concat(
                        this.Vertex.ToString(CultureInfo.InvariantCulture),
                        "/",
                        this.Texture.ToString(CultureInfo.InvariantCulture));
                }
            }
            else
            {
                if (this.Texture == 0)
                {
                    return string.Concat(
                        this.Vertex.ToString(CultureInfo.InvariantCulture),
                        "//",
                        this.Normal.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    return string.Concat(
                        this.Vertex.ToString(CultureInfo.InvariantCulture),
                        "/",
                        this.Texture.ToString(CultureInfo.InvariantCulture),
                        "/",
                        this.Normal.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        public static bool operator ==(ObjTriplet left, ObjTriplet right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ObjTriplet left, ObjTriplet right)
        {
            return !(left == right);
        }
    }
}
