export namespace ApplicationHTML {
    export class DocumentManager {
        public static GetElementByID<T extends HTMLElement>(name: string): T {
            return (document.getElementById(name) as T)
        }
    }
}
