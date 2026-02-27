const GraphicsPage = {
    template: `
        <div style="padding-bottom:32px">
            <!-- Shapes -->
            <div class="section-header">Custom Shapes</div>
            <div class="card">
                <div class="canvas-container">
                    <canvas ref="shapesCanvas" width="320" height="200"></canvas>
                </div>
            </div>

            <!-- Gradients -->
            <div class="section-header">Gradients</div>
            <div class="card">
                <div class="canvas-container">
                    <canvas ref="gradientCanvas" width="320" height="120"></canvas>
                </div>
            </div>

            <!-- Star Path -->
            <div class="section-header">Path Drawing</div>
            <div class="card">
                <div class="canvas-container">
                    <canvas ref="starCanvas" width="200" height="200"></canvas>
                </div>
            </div>

            <!-- Bezier Curves -->
            <div class="section-header">Bezier Curves</div>
            <div class="card">
                <div class="canvas-container">
                    <canvas ref="bezierCanvas" width="320" height="160"></canvas>
                </div>
            </div>

            <!-- Animations -->
            <div class="section-header">Animations</div>
            <div class="card">
                <div ref="animBox" class="anim-box" :style="animStyle">Anim</div>
                <div class="anim-controls">
                    <button class="anim-btn" @click="animFade">Fade</button>
                    <button class="anim-btn" @click="animRotate">Rotate</button>
                    <button class="anim-btn" @click="animScale">Scale</button>
                    <button class="anim-btn" @click="animTranslate">Translate</button>
                    <button class="anim-btn" @click="animComposite">Composite</button>
                </div>
            </div>

            <!-- Visual States -->
            <div class="section-header">Visual States</div>
            <div class="card">
                <div class="state-box"
                     :class="stateClass"
                     @mousedown="state='pressed'" @mouseup="state='normal'"
                     @mouseenter="state='hover'" @mouseleave="state='normal'"
                     @touchstart.prevent="state='pressed'" @touchend="state='normal'">
                    {{ stateLabel }}
                </div>
            </div>
        </div>
    `,
    setup() {
        const shapesCanvas = ref(null);
        const gradientCanvas = ref(null);
        const starCanvas = ref(null);
        const bezierCanvas = ref(null);
        const animBox = ref(null);
        const animStyle = ref({});
        const state = ref('normal');

        const stateClass = computed(() => 'state-' + state.value);
        const stateLabel = computed(() => {
            const labels = { normal: 'Tap or hover me!', pressed: 'Pressed! 👆', hover: 'Hovering! 🖱️' };
            return labels[state.value];
        });

        const drawShapes = () => {
            const canvas = shapesCanvas.value;
            if (!canvas) return;
            const ctx = canvas.getContext('2d');

            ctx.beginPath();
            ctx.arc(60, 100, 45, 0, Math.PI * 2);
            ctx.fillStyle = '#512BD4';
            ctx.fill();

            ctx.beginPath();
            ctx.roundRect(130, 55, 80, 90, 12);
            ctx.fillStyle = '#0CA789';
            ctx.fill();

            ctx.beginPath();
            ctx.moveTo(270, 55);
            ctx.lineTo(320, 145);
            ctx.lineTo(220, 145);
            ctx.closePath();
            ctx.fillStyle = '#E8A317';
            ctx.fill();

            ctx.fillStyle = '#FFFFFF';
            ctx.font = '13px -apple-system, sans-serif';
            ctx.textAlign = 'center';
            ctx.fillText('Circle', 60, 105);
            ctx.fillText('Rect', 170, 105);
            ctx.fillText('Triangle', 270, 110);
        };

        const drawGradients = () => {
            const canvas = gradientCanvas.value;
            if (!canvas) return;
            const ctx = canvas.getContext('2d');

            const lg = ctx.createLinearGradient(0, 0, 150, 0);
            lg.addColorStop(0, '#512BD4');
            lg.addColorStop(1, '#0CA789');
            ctx.fillStyle = lg;
            ctx.beginPath();
            ctx.roundRect(10, 10, 140, 100, 12);
            ctx.fill();

            const rg = ctx.createRadialGradient(245, 60, 10, 245, 60, 60);
            rg.addColorStop(0, '#E8A317');
            rg.addColorStop(1, '#D64045');
            ctx.fillStyle = rg;
            ctx.beginPath();
            ctx.roundRect(170, 10, 140, 100, 12);
            ctx.fill();

            ctx.fillStyle = '#FFFFFF';
            ctx.font = '12px -apple-system, sans-serif';
            ctx.textAlign = 'center';
            ctx.fillText('Linear', 80, 65);
            ctx.fillText('Radial', 240, 65);
        };

        const drawStar = () => {
            const canvas = starCanvas.value;
            if (!canvas) return;
            const ctx = canvas.getContext('2d');
            const cx = 100, cy = 100, outerR = 80, innerR = 35, points = 5;

            ctx.beginPath();
            for (let i = 0; i < points * 2; i++) {
                const r = i % 2 === 0 ? outerR : innerR;
                const angle = (Math.PI / points) * i - Math.PI / 2;
                const x = cx + r * Math.cos(angle);
                const y = cy + r * Math.sin(angle);
                if (i === 0) ctx.moveTo(x, y);
                else ctx.lineTo(x, y);
            }
            ctx.closePath();
            const sg = ctx.createLinearGradient(20, 20, 180, 180);
            sg.addColorStop(0, '#512BD4');
            sg.addColorStop(1, '#D64045');
            ctx.fillStyle = sg;
            ctx.fill();
            ctx.strokeStyle = '#E8A317';
            ctx.lineWidth = 2;
            ctx.stroke();
        };

        const drawBezier = () => {
            const canvas = bezierCanvas.value;
            if (!canvas) return;
            const ctx = canvas.getContext('2d');

            ctx.beginPath();
            ctx.moveTo(20, 140);
            ctx.bezierCurveTo(80, 10, 240, 10, 300, 140);
            ctx.strokeStyle = '#512BD4';
            ctx.lineWidth = 3;
            ctx.stroke();

            ctx.beginPath();
            ctx.moveTo(20, 80);
            ctx.quadraticCurveTo(160, 0, 300, 80);
            ctx.strokeStyle = '#0CA789';
            ctx.lineWidth = 3;
            ctx.stroke();

            ctx.fillStyle = '#D64045';
            [{ x: 80, y: 10 }, { x: 240, y: 10 }, { x: 160, y: 0 }].forEach(p => {
                ctx.beginPath();
                ctx.arc(p.x, p.y + 5, 4, 0, Math.PI * 2);
                ctx.fill();
            });
        };

        const resetAnim = () => { animStyle.value = { transition: 'all 0.5s ease' }; };

        const animFade = () => {
            animStyle.value = { transition: 'opacity 0.5s', opacity: 0 };
            setTimeout(() => { animStyle.value = { transition: 'opacity 0.5s', opacity: 1 }; }, 600);
        };

        const animRotate = () => {
            animStyle.value = { transition: 'transform 0.6s ease', transform: 'rotate(360deg)' };
            setTimeout(resetAnim, 700);
        };

        const animScale = () => {
            animStyle.value = { transition: 'transform 0.3s ease', transform: 'scale(1.5)' };
            setTimeout(() => { animStyle.value = { transition: 'transform 0.3s ease', transform: 'scale(1)' }; }, 400);
        };

        const animTranslate = () => {
            animStyle.value = { transition: 'transform 0.4s ease', transform: 'translateX(80px)' };
            setTimeout(() => { animStyle.value = { transition: 'transform 0.4s ease', transform: 'translateX(0)' }; }, 500);
        };

        const animComposite = () => {
            animStyle.value = { transition: 'all 0.6s ease', transform: 'rotate(180deg) scale(1.3)', opacity: 0.5 };
            setTimeout(() => { animStyle.value = { transition: 'all 0.6s ease', transform: 'rotate(0) scale(1)', opacity: 1 }; }, 700);
        };

        onMounted(() => {
            nextTick(() => {
                drawShapes();
                drawGradients();
                drawStar();
                drawBezier();
            });
        });

        return {
            shapesCanvas, gradientCanvas, starCanvas, bezierCanvas,
            animBox, animStyle, state, stateClass, stateLabel,
            animFade, animRotate, animScale, animTranslate, animComposite
        };
    }
};
