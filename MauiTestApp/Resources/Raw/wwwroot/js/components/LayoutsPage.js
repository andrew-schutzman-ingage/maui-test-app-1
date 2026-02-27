const LayoutsPage = {
    template: `
        <div style="padding-bottom:32px">
            <!-- VerticalStackLayout -->
            <div class="section-header">Vertical Stack</div>
            <div class="card">
                <div class="vstack">
                    <div class="layout-box">Item 1</div>
                    <div class="layout-box" style="background:var(--success)">Item 2</div>
                    <div class="layout-box" style="background:var(--warning)">Item 3</div>
                </div>
            </div>

            <!-- HorizontalStackLayout -->
            <div class="section-header">Horizontal Stack</div>
            <div class="card">
                <div class="hstack">
                    <div class="layout-box">A</div>
                    <div class="layout-box" style="background:var(--success)">B</div>
                    <div class="layout-box" style="background:var(--warning)">C</div>
                    <div class="layout-box" style="background:var(--danger)">D</div>
                </div>
            </div>

            <!-- Grid -->
            <div class="section-header">Grid Layout</div>
            <div class="card">
                <div class="grid-demo">
                    <div class="layout-box">1,1</div>
                    <div class="layout-box grid-span-2" style="background:var(--success)">1,2 (span 2)</div>
                    <div class="layout-box grid-row-span-2" style="background:var(--warning)">2,1 (row span)</div>
                    <div class="layout-box" style="background:var(--danger)">2,2</div>
                    <div class="layout-box" style="background:var(--accent)">2,3</div>
                    <div class="layout-box grid-span-2" style="background:#E67E22">3,2 (span 2)</div>
                </div>
            </div>

            <!-- FlexLayout -->
            <div class="section-header">Flex Layout</div>
            <div class="card">
                <div class="flex-demo">
                    <div class="layout-box">Flex 1</div>
                    <div class="layout-box" style="background:var(--success);min-width:120px">Flex 2 (wider)</div>
                    <div class="layout-box" style="background:var(--warning)">Flex 3</div>
                    <div class="layout-box" style="background:var(--danger)">Flex 4</div>
                    <div class="layout-box" style="background:var(--accent)">Flex 5</div>
                </div>
            </div>

            <!-- AbsoluteLayout -->
            <div class="section-header">Absolute Layout</div>
            <div class="card">
                <div class="absolute-demo">
                    <div class="layout-box" style="top:10px;left:10px;width:100px;height:40px">Top-Left</div>
                    <div class="layout-box" style="top:20px;right:10px;width:80px;height:80px;background:var(--success);left:auto">Center</div>
                    <div class="layout-box" style="bottom:10px;left:50%;transform:translateX(-50%);width:140px;height:40px;background:var(--warning);top:auto">Bottom-Center</div>
                </div>
            </div>
        </div>
    `
};
