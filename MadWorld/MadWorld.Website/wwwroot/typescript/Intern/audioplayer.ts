import { ApplicationHTML } from '../base/application-html';

namespace AudioManager {
    class AudioPlayer {
        private Name: string = "";
        private Player: HTMLAudioElement = null;

        public Create(name: string) {
            this.Name = name;
            this.Player = ApplicationHTML.DocumentManager.GetElementByID<HTMLAudioElement>(this.Name);
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
