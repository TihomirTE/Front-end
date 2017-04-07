using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Surfaces
{
    public abstract class Surface : ModelVisual3D
    {
        private static PropertyHolder<Material, Surface> materialProperty =
            new PropertyHolder<Material, Surface>("Material", null, OnMaterialChanged);

        private static PropertyHolder<Material, Surface> backMaterialProperty =
            new PropertyHolder<Material, Surface>("BackMaterial", null, OnBackMaterialChanged);

        private static PropertyHolder<bool, Surface> visibleProperty =
            new PropertyHolder<bool, Surface>("Visible", true, OnVisibleChanged);

        private readonly GeometryModel3D content = new GeometryModel3D();

        public Surface()
        {
            this.Content = this.content;
            this.content.Geometry = CreateMesh();
        }

        public Material Material
        {
            get { return materialProperty.Get(this); }
            set { materialProperty.Set(this, value); }
        }

        public Material BackMaterial
        {
            get { return backMaterialProperty.Get(this); }
            set { backMaterialProperty.Set(this, value); }
        }

        public bool Visible
        {
            get { return visibleProperty.Get(this); }
            set { visibleProperty.Set(this, value); }
        }

        protected static void OnGeometryChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnGeometryChanged();
        }

        protected abstract Geometry3D CreateMesh();

        private static void OnMaterialChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnMaterialChanged();
        }

        private static void OnBackMaterialChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnBackMaterialChanged();
        }

        private static void OnVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnVisibleChanged();
        }

        private void OnMaterialChanged()
        {
            SetContentMaterial();
        }

        private void OnBackMaterialChanged()
        {
            SetContentBackMaterial();
        }

        private void OnVisibleChanged()
        {
            SetContentMaterial();
            SetContentBackMaterial();
        }

        private void SetContentMaterial()
        {
            content.Material = Visible ? Material : null;
        }

        private void SetContentBackMaterial()
        {
            content.BackMaterial = Visible ? BackMaterial : null;
        }

        private void OnGeometryChanged()
        {
            content.Geometry = CreateMesh();
        }
    }
}
