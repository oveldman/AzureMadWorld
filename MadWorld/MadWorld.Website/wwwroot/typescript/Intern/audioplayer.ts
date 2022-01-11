import { DocumentManager } from '../base/documenthandler';

namespace AudioManager {
    class AudioPlayer {
        private Name: string = "";
        private Player: HTMLAudioElement = null;

        public Init(name: string) {
            this.Name = name;
            this.Player = DocumentManager.GetElementByID<HTMLAudioElement>(this.Name);
        }

        public Play() {
            this.Player.play();
        }
    }

    export function Load() {
        window["AudioPlayer"] = new AudioPlayer();
    }
}

AudioManager.Load();
