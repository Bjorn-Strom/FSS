import { defineConfig } from 'vite';

export default defineConfig({
    base: "./",
    root: "dist",
    build: {
        outdir: "../public",
        emptyOutDir: true,
        sourcemap: false,
    }
})