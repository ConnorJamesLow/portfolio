import app from './app';

declare global {
    interface Window {
        lib: typeof app
    }
}

export default app;
