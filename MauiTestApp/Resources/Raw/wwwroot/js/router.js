const routes = [
    { path: '/', component: HomePage, meta: { title: 'MAUI Feature Showcase' } },
    { path: '/controls', component: ControlsPage, meta: { title: 'Controls Gallery' } },
    { path: '/layouts', component: LayoutsPage, meta: { title: 'Layouts Demo' } },
    { path: '/data', component: DataPage, meta: { title: 'CollectionView & Data' } },
    { path: '/graphics', component: GraphicsPage, meta: { title: 'Graphics & Animations' } },
    { path: '/platform', component: PlatformPage, meta: { title: 'Platform Features' } }
];

const router = createRouter({
    history: createWebHashHistory(),
    routes
});
