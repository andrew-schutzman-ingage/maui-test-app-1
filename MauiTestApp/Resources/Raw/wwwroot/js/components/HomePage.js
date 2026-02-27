const HomePage = {
    template: `
        <div>
            <div class="card" style="margin-top:12px">
                <div class="hero">
                    <h2>.NET MAUI</h2>
                    <div class="subtitle">Feature Showcase</div>
                    <div class="desc">Explore the variety of features available with .NET MAUI + Vue.js in a native WebView.</div>
                </div>
            </div>

            <div v-for="cat in categories" :key="cat.name">
                <div class="section-header">{{ cat.icon }} {{ cat.name }}</div>
                <div class="section-desc">{{ cat.description }}</div>
                <div v-for="demo in cat.demos" :key="demo.name"
                     class="card card-tap" @click="$router.push(demo.route)">
                    <div class="demo-row">
                        <span class="demo-icon">{{ demo.icon }}</span>
                        <div class="demo-info">
                            <h3>{{ demo.name }}</h3>
                            <p>{{ demo.description }}</p>
                        </div>
                        <span class="demo-arrow">›</span>
                    </div>
                </div>
            </div>

            <div class="footer">Built with .NET MAUI WebView &amp; Vue.js</div>
        </div>
    `,
    setup() {
        const categories = [
            {
                name: 'Controls', icon: '🎛️', description: 'Interactive UI controls',
                demos: [{ name: 'Controls Gallery', description: 'Buttons, entries, sliders, pickers, and more', icon: '🔘', route: '/controls' }]
            },
            {
                name: 'Layouts', icon: '📐', description: 'Layout containers and arrangement',
                demos: [{ name: 'Layouts Demo', description: 'Grid, Stack, Flex, and Absolute layouts', icon: '📏', route: '/layouts' }]
            },
            {
                name: 'Data', icon: '📊', description: 'Data display and binding',
                demos: [{ name: 'CollectionView', description: 'Grouping, search, refresh, and swipe actions', icon: '📋', route: '/data' }]
            },
            {
                name: 'Graphics', icon: '🎨', description: 'Drawing and animations',
                demos: [{ name: 'Graphics & Animations', description: 'Shapes, paths, gradients, and animations', icon: '✨', route: '/graphics' }]
            },
            {
                name: 'Platform', icon: '📱', description: 'Device and platform APIs',
                demos: [{ name: 'Platform Features', description: 'Device info, connectivity, clipboard, share, and more', icon: '⚙️', route: '/platform' }]
            }
        ];
        return { categories };
    }
};
