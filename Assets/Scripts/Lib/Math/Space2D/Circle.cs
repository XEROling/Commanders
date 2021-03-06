using sMath = System.Math;

namespace Assets.Scripts.Lib.Math.Space2D {
    internal class Circle {
        public readonly static Circle UNIT_SPHERE = new(Point.ORIGIN, 1);

        public bool includesPoint(Point point)
            => this.center.distance(point) <= this.radius;
        public bool onPoint(Point point)
            => this.center.distance(point) == this.radius;

        public double distance_Center(Circle sphere)
            => this.center.distance(sphere.center);

        /// <returns>
        ///     <list type="bullet">
        ///     <item> &gt;0 • No intersection • The distance between the spheres </item>
        ///     <item> =0 • Touching edges </item>
        ///     <item> &lt;0 • Intersecting </item>
        ///     </list>
        /// </returns>
        public double distance_Edge(Circle sphere)
            => this.distance_Center(sphere) - (this.radius + sphere.radius);

        public bool intersectsSphere(Circle sphere)
           => this.distance_Edge(sphere) <= 0;

        //TODO: TEST Circle.howClose(Point)
        /// <returns> Ratio of how close <paramref name="point"/> is to <see cref="center"/>
        /// relative to <see cref="radius"/> </returns>
        public double howClose(Point point) {
            double distance = this.center.distance(point);
            //? close 0 -- 1 far
            double ratio_inverse = distance / this.radius;
            //? close 1 -- 0 far
            double ratio = sMath.Abs(ratio_inverse - 1);
            return Range.ZERO_ONE.toRange(ratio);
        }


        public Point center { get; set; }
        public double radius { get; set; }
        public double volume
            => 4 * sMath.PI * sMath.Pow(this.radius, 2);

        public Circle(double x, double y, double radius) {
            this.center = new Point(x, y);
            this.radius = radius;
        }
        public Circle(Point center, double radius) {
            this.center = center;
            this.radius = radius;
        }
    }
}